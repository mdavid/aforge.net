// AForge Image Processing Library
// AForge.NET framework
//
// Copyright © Andrew Kirillov, 2005-2008
// andrew.kirillov@gmail.com
//

namespace AForge.Imaging
{
    using System;
    using System.Collections.Generic;
    using System.Drawing.Imaging;
    using System.Drawing;

    /// <summary>
    /// Possible features to be computed on blobs.
    /// </summary>
    /// 
    /// <remarks>The enumeration defines possible features to  be computed on blobs</remarks>
    /// 
    public enum ComputedFeatures
    {
        /// <summary>
        /// Number of pixels
        /// </summary>
        Area,

        /// <summary>
        /// Mean of Blobs pixels positions.
        /// </summary>
        GravityCenter,

        /// <summary>
        /// Mean of blobs Pixels values
        /// </summary>
        Mean,

        /// <summary>
        /// Standard deviation of pixels values
        /// </summary>
        StandardDeviation
    }

    /// <summary>
    /// Class computing statistics on binary or grayscale Blobs
    /// </summary>
    /// 
    /// <remarks>
    /// <para>This class allows computation of statistics on a blob's list</para>
    /// <para>Sample usage:</para>
    /// <code>
    /// BlobCounter bc = new BlobCounter();
    /// bc.ProcessImage(bmp);
    /// Blob[] blobs = bc.GetObjects(bmp);
    ///
    /// BlobStatistics bs = new BlobStatistics();
    /// bs.SetBlobs(blobs);
    /// bs.SetFeatureList(new ComputedFeatures[]{
    ///     ComputedFeatures.Area,
    ///     ComputedFeatures.GravityCenter,
    ///     ComputedFeatures.Mean,
    ///     ComputedFeatures.StandardDeviation});
    /// bs.Process();
    /// object[][] results = bs.GetResults();
    /// </code>
    /// </remarks>
    /// 
    public class BlobStatistics
    {
        private List<ComputedFeatures> featuresList;
        private List<Blob> blobList;
        private Dictionary<Blob, Dictionary<ComputedFeatures, object>> resultsDictionary;

        /// <summary>
        /// Constructor initializing private datas
        /// </summary>
        public BlobStatistics()
        {
            featuresList = new List<ComputedFeatures>();
            blobList = new List<Blob>();
        }

        /// <summary>
        /// Sets the feature list to be processed from array
        /// </summary>
        /// 
        /// <param name="features">1D array of ComputedFeatures indicating which features to process</param>
        /// 
        public void SetFeatureList(ComputedFeatures[] features)
        {
            featuresList.Clear();
            featuresList.AddRange(features);
        }

        /// <summary>
        /// Sets the blob list to be processed from array
        /// </summary>
        ///
        /// <param name="blobs">1D array of blobs to compute. blobs image must be binary or grayscale</param>
        /// 
        public void SetBlobs(Blob[] blobs)
        {
            blobList.Clear();
            blobList.AddRange(blobs);
        }

        /// <summary>
        /// Verify if blobs images are binary or grayscale
        /// </summary>
        private bool CheckBlobsFormat()
        {
            foreach (Blob b in blobList)
            {
                if (b.Image.PixelFormat != PixelFormat.Format8bppIndexed &&
                    b.Image.PixelFormat != PixelFormat.Format1bppIndexed)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Return features result for one blob
        /// </summary>
        /// 
        /// <param name="blob">The blob on wich the result will be retrieved</param>
        /// <param name="feature">Specify the asked feature</param>
        /// 
        /// <remarks>
        /// Each result is returned as object and will be cast to the corresponding type
        /// </remarks>
        public object GetResult(Blob blob, ComputedFeatures feature)
        {
            return resultsDictionary[blob][feature];
        }

        /// <summary>
        /// Return results for one blob.
        /// </summary>
        /// 
        /// <param name="blob">The blob on wich results will be retrieved</param>
        /// 
        /// <remarks>
        /// Results are returned in the order of the list of features
        /// Each result is returned as object and will be cast to the corresponding type
        /// </remarks>
        public object[] GetResults(Blob blob)
        {
            object[] array = new object[resultsDictionary[blob].Count];
            resultsDictionary[blob].Values.CopyTo(array, 0);
            return array;
        }

        /// <summary>
        /// Return features results for all blobs
        /// </summary>
        /// 
        /// <remarks>
        /// return a matrix of results object sorted by Blob then by features
        /// Each result is returned as object and will be cast to the corresponding type
        /// </remarks>
        public object[][] GetResults()
        {
            object[][] matrix = new object[resultsDictionary.Count][];
            int index = 0;
            foreach (Dictionary<ComputedFeatures, object> dict in resultsDictionary.Values)
            {
                matrix[index] = new object[dict.Count];
                dict.Values.CopyTo(matrix[index],0);
                index++;
            }
            return matrix;
        }

        /// <summary>
        /// Return features results for all blobs in a dictionary
        /// </summary>
        /// 
        /// <remarks>
        /// Use of Dictionary provide fast way to accessing datas in huge dataset 
        /// </remarks>
        public Dictionary<Blob, Dictionary<ComputedFeatures, object>> GetResultsDictionary()
        {
            return resultsDictionary;
        }

        /// <summary>
        /// Compute selected features on blobs list
        /// </summary>
        /// 
        /// <remarks>
        /// At this time, each feature is computed standalone.
        /// Next, this method will be optimized (re-use of calculated features, and use of threads to
        /// take advantage of actual machine architecture.
        /// </remarks>
        public void Process()
        {
            //Check all conditions are satisfied
            if (featuresList.Count == 0)
                throw new ApplicationException("One or more features must be selected");
            if (blobList.Count == 0)
                throw new ApplicationException("Blob list is empty. Add blob with SetBlob method");
            if (!CheckBlobsFormat())
                throw new ApplicationException("Blob's image are not binary or grayscale");

            //Creating the dictionary of results
            resultsDictionary = new Dictionary<Blob, Dictionary<ComputedFeatures, object>>();

            foreach (Blob b in blobList)
            {
                // lock bitmap data
                BitmapData imageData = b.Image.LockBits(
                    new Rectangle(0, 0, b.Image.Width, b.Image.Height),
                    ImageLockMode.ReadOnly, b.Image.PixelFormat);

                //Creating dictionary of result for the current blob
                Dictionary<ComputedFeatures,object> blobResults = new Dictionary<ComputedFeatures,object>();

                //Processing parameters

                //Compute area
                if(featuresList.Contains(ComputedFeatures.Area))
                    blobResults.Add(ComputedFeatures.Area,ProcessArea(b,imageData));

                //Compute mean
                if (featuresList.Contains(ComputedFeatures.Mean))
                    blobResults.Add(ComputedFeatures.Mean, ProcessMean(b, imageData));

                //Compute gravity center
                if (featuresList.Contains(ComputedFeatures.GravityCenter))
                    blobResults.Add(ComputedFeatures.GravityCenter, ProcessGravityCenter(b, imageData));

                //Compute standard Deviation
                if (featuresList.Contains(ComputedFeatures.StandardDeviation))
                    blobResults.Add(ComputedFeatures.StandardDeviation, ProcessStandardDeviation(b, imageData));

                //Adding current blob result to global result dictionary
                resultsDictionary.Add(b, blobResults);
                
                // unlock image
                b.Image.UnlockBits(imageData);
            }

        }

        /// <summary>
        /// Process Area feature on specified blob
        /// </summary>
        /// 
        /// <param name="blob">The blob on wich area will be computed</param>
        /// <param name="imageData">The BitmapData that is locked in process method</param>
        /// 
        /// <returns>Return a double representing the area of the blob in pixels</returns>
        /// 
        private double ProcessArea(Blob blob, BitmapData imageData)
        {
            double area = 0.0;

            byte value;
            int offset = imageData.Stride - imageData.Width;

            // do the job
            unsafe
            {
                byte* p = (byte*)imageData.Scan0.ToPointer();

                // for each pixel
                for (int y = 0; y < imageData.Height; y++)
                {
                    // for each pixel
                    for (int x = 0; x < imageData.Width; x++, p++)
                    {
                        // get pixel value
                        value = *p;
                        if (value != 0)
                        {
                            area++;
                        }
                    }
                    p += offset;
                }
            }
            return area;
        }

        /// <summary>
        /// Process Mean feature on specified blob
        /// </summary>
        /// 
        /// <param name="blob">The blob on wich mean will be computed</param>
        /// <param name="imageData">The BitmapData that is locked in process method</param>
        ///
        /// <returns>Return a double representing mean of pixels values of the blob</returns>
        ///
        private double ProcessMean(Blob blob, BitmapData imageData)
        {
            double sum = 0.0;
            double pixelCount = 0.0;

            byte value;
            int offset = imageData.Stride - imageData.Width;

            // do the job
            unsafe
            {
                byte* p = (byte*)imageData.Scan0.ToPointer();

                // for each pixel
                for (int y = 0; y < imageData.Height; y++)
                {
                    // for each pixel
                    for (int x = 0; x < imageData.Width; x++, p++)
                    {
                        // get pixel value
                        value = *p;
                        if (value != 0)
                        {
                            //Mean
                            sum += value;
                            pixelCount++;
                        }
                    }
                    p += offset;
                }
                return sum / pixelCount;
            }
        }

        /// <summary>
        /// Calculate the gravity center of the specified blob.
        /// </summary>
        /// 
        /// <param name="blob">The blob on wich gravity center will be computed</param>
        /// <param name="imageData">The BitmapData that is locked in process method</param>
        /// 
        /// <returns>Return 2-upplet of double representing x and y coordinates of gravity center of the blob</returns>
        /// 
        private double[] ProcessGravityCenter(Blob blob, BitmapData imageData)
        {
            double xCenter = 0.0;
            double yCenter = 0.0;
            double pixelCount = 0.0;
            byte value;
            int offset = imageData.Stride - imageData.Width;

            // do the job
            unsafe
            {
                byte* p = (byte*)imageData.Scan0.ToPointer();

                // for each pixel
                for (int y = 0; y < imageData.Height; y++)
                {
                    // for each pixel
                    for (int x = 0; x < imageData.Width; x++, p++)
                    {
                        // get pixel value
                        value = *p;
                        if (value != 0)
                        {
                            //Gravity Center
                            xCenter += x;
                            yCenter += y;

                            pixelCount++;
                        }
                    }
                    p += offset;
                }

                //Gravity Center
                return new double[] { xCenter / pixelCount, yCenter/pixelCount };
            }
        }

        /// <summary>
        /// Process standard deviation feature on specified blob
        /// </summary>
        /// 
        /// <param name="blob">The blob on wich standard deviation will be computed</param>
        /// <param name="imageData">The BitmapData that is locked in process method</param>
        ///
        /// <returns>Return a double representing the standard deviation of pixels values of the blob</returns>
        ///
        private double ProcessStandardDeviation(Blob blob, BitmapData imageData)
        {
            double std = 0.0;
            double mean = 0.0;
            double pixelCount = 0.0;

            byte value;
            int offset = imageData.Stride - imageData.Width;

            // do the job
            unsafe
            {
                byte* p = (byte*)imageData.Scan0.ToPointer();

                // for each pixel
                for (int y = 0; y < imageData.Height; y++)
                {
                    // for each pixel
                    for (int x = 0; x < imageData.Width; x++, p++)
                    {
                        // get pixel value
                        value = *p;
                        if (value != 0)
                        {
                            //Mean
                            mean += value;

                            //std
                            std += value * value;

                            pixelCount++;
                        }
                    }
                    p += offset;
                }
                mean /= pixelCount;
                return Math.Sqrt((std / pixelCount) - mean*mean);
            }
        }
    }
}
