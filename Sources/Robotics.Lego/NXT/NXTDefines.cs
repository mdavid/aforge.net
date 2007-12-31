// AForge Lego Robotics Library
// AForge.NET framework
//
// Copyright © Andrew Kirillov, 2007
// andrew.kirillov@gmail.com
//

namespace AForge.Robotics.Lego.NXT
{
    using System;

    /// <summary>
    /// Definition of command types supported by Lego Mindstorms NXT brick.
    /// </summary>
    /// 
    public enum CommandType : byte
    {
        /// <summary>
        /// Direct command, which requires reply.
        /// </summary>
        DirectCommand = 0x00,

        /// <summary>
        /// System command, which requies reply.
        /// </summary>
        SystemCommand = 0x01,

        /// <summary>
        /// Reply command received from NXT brick.
        /// </summary>
        ReplyCommand = 0x02,

        /// <summary>
        /// Direct command, which does not require reply.
        /// </summary>
        DirectCommandWithoutReply = 0x80,

        /// <summary>
        /// System command, which does not require reply.
        /// </summary>
        SystemCommandWithoutReply = 0x81
    }

    /// <summary>
    /// Definition of system commands supported by Lego Mindstorms NXT brick.
    /// </summary>
    /// 
    public enum SystemCommand : byte
    {
        /// <summary>
        /// Get firmware version of NXT brick.
        /// </summary>
        GetFirmwareVersion = 0x88,

        /// <summary>
        /// Set NXT brick name.
        /// </summary>
        SetBrickName = 0x98,

        /// <summary>
        /// Get device information.
        /// </summary>
        GetDeviceInfo = 0x9B
    }

    /// <summary>
    /// Definition of direct commands supported by Lego Mindstorms NXT brick.
    /// </summary>
    /// 
    public enum DirectCommand : byte
    {
        /// <summary>
        /// Get battery level.
        /// </summary>
        GetBatteryLevel = 0x0B,

        /// <summary>
        /// Set output state.
        /// </summary>
        SetOutputState = 0x04,

        /// <summary>
        /// Get output state.
        /// </summary>
        GetOutputState = 0x06,

        /// <summary>
        /// Reset motor position.
        /// </summary>
        ResetMotorPosition = 0x0A
    }

    /// <summary>
    /// Definition of possible NXT output ports.
    /// </summary>
    /// 
    public enum OutputPort : byte
    {
        /// <summary>
        /// First motor coonected to port A.
        /// </summary>
        MotorA = 0x00,

        /// <summary>
        /// Second motor coonected to port B.
        /// </summary>
        MotorB = 0x01,

        /// <summary>
        /// Third motor coonected to port C.
        /// </summary>
        MotorC = 0x02,

        /// <summary>
        /// All ports.
        /// </summary>
        All = 0xFF
    }

    /// <summary>
    /// Definition of error codes, which can be reported by Lego Mindstorms NXT brick.
    /// </summary>
    public enum DeviceError : byte
    {
        /// <summary>
        /// Success.
        /// </summary>
        Success = 0x00,

        /// <summary>
        /// No more handles.
        /// </summary>
        NoMoreHandles = 0x81,

        /// <summary>
        /// No space.
        /// </summary>
        NoSpace = 0x82,

        /// <summary>
        /// No more files.
        /// </summary>
        NoMmoreFiles = 0x83,

        /// <summary>
        /// End of file expected.
        /// </summary>
        EndOfFileExpected = 0x84,

        /// <summary>
        /// End of file.
        /// </summary>
        EndOfFile = 0x85,

        /// <summary>
        /// Not a linear file.
        /// </summary>
        NotLinearFile = 0x86,

        /// <summary>
        /// File not found.
        /// </summary>
        FileNotFound = 0x87,

        /// <summary>
        /// Handle already closed.
        /// </summary>
        HandleAlreadyClosed = 0x88,

        /// <summary>
        /// No linear space.
        /// </summary>
        NoLinearSpace = 0x89,

        /// <summary>
        /// Undefined error.
        /// </summary>
        UndefinedError = 0x8A,

        /// <summary>
        /// File is busy.
        /// </summary>
        FileIsBusy = 0x8B,

        /// <summary>
        /// No write buffers.
        /// </summary>
        NoWriteBuffers = 0x8C,

        /// <summary>
        /// Append not possible.
        /// </summary>
        AppendNotPossible = 0x8D,

        /// <summary>
        /// File is full.
        /// </summary>
        FileIsFull = 0x8E,

        /// <summary>
        /// File exists.
        /// </summary>
        FileExists = 0x8F,

        /// <summary>
        /// Module not found.
        /// </summary>
        ModuleNotFound = 0x90,

        /// <summary>
        /// Out of boundary.
        /// </summary>
        OutOfBoundary = 0x91,

        /// <summary>
        /// Illegal file name.
        /// </summary>
        IllegalFileName = 0x92,

        /// <summary>
        /// Illegal handle.
        /// </summary>
        IllegalHandle = 0x93,

        /// <summary>
        /// Pending communication transaction in progress.
        /// </summary>
        PendingCommunicationTransaction = 0x20,

        /// <summary>
        /// Specified mailbox queue is empty.
        /// </summary>
        MailboxQueueIsEmpty = 0x40,

        /// <summary>
        /// Request failed (i.e. specified file not found).
        /// </summary>
        RequestFailed = 0xBD,

        /// <summary>
        /// Unknown command opcode.
        /// </summary>
        UnknownCommandOpcode = 0xBE,

        /// <summary>
        /// Insane packet.
        /// </summary>
        InsanePacket = 0xBF,

        /// <summary>
        /// Data contains out-of-range values.
        /// </summary>
        OutOfRangeData = 0xC0,

        /// <summary>
        /// Communication bus error.
        /// </summary>
        CommunicationBusError = 0xDD,

        /// <summary>
        /// No free memory in communication buffer.
        /// </summary>
        NoFreeMemoryForCommunication = 0xDE,

        /// <summary>
        /// Specified channel/connection is not valid.
        /// </summary>
        InvalidChannel = 0xDF,

        /// <summary>
        /// Specified channel/connection not configured or busy.
        /// </summary>
        BusyChannel = 0xE0,

        /// <summary>
        /// No active program.
        /// </summary>
        NoActiveProgram = 0xEC,

        /// <summary>
        /// Illegal size specified.
        /// </summary>
        IllegalSizeSpecified = 0xED,

        /// <summary>
        /// Illegal mailbox queue ID specified.
        /// </summary>
        IllegalMailboxID = 0xEE,

        /// <summary>
        /// Attempted to access invalid field of a structure.
        /// </summary>
        InvalidField = 0xEF,

        /// <summary>
        /// Bad input or output specified.
        /// </summary>
        BadInputOrOutput = 0xF0,

        /// <summary>
        /// Insufficient memory available.
        /// </summary>
        InsufficientMemory = 0xFB,

        /// <summary>
        /// Bad arguments.
        /// </summary>
        BadArguments = 0xFF
    }

    /// <summary>
    /// List of possible motor modes.
    /// </summary>
    /// 
    /// <remarks>Motor mode is a bit field, so several modes can be combined.</remarks>
    /// 
    [FlagsAttribute]
    public enum MotorMode : byte
    {
        /// <summary>
        /// Mode is not set.
        /// </summary>
        None = 0x00,

        /// <summary>
        /// Turn on the motor.
        /// </summary>
        On = 0x01,

        /// <summary>
        /// Brake.
        /// </summary>
        Brake = 0x02,

        /// <summary>
        /// Turn on regulated mode.
        /// </summary>
        Regulated = 0x04
    }

    /// <summary>
    /// Motor regulation modes.
    /// </summary>
    /// 
    public enum RegulationMode : byte
    {
        /// <summary>
        /// No regulation will be enabled.
        /// </summary>
        Idle = 0x00,

        /// <summary>
        /// Power control will be enabled on specified motor.
        /// </summary>
        Speed = 0x01,

        /// <summary>
        /// Synchronization will be enabled.
        /// </summary>
        /// 
        /// <remarks><note>Synchronization need to be enabled on two motors.</note></remarks>
        /// 
        Sync = 0x02
    }

    /// <summary>
    /// Motor run states.
    /// </summary>
    /// 
    public enum RunState : byte
    {
        /// <summary>
        /// Motor will be idle.
        /// </summary>
        Idle = 0x00,

        /// <summary>
        /// Motor will ramp-up.
        /// </summary>
        RampUp = 0x10,

        /// <summary>
        /// Motor will be running.
        /// </summary>
        Running = 0x20,

        /// <summary>
        /// Motor will ramp-down.
        /// </summary>
        RampDown = 0x40
    }
}
