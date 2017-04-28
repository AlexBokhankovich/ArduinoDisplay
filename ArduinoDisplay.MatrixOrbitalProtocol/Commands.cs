namespace ArduinoDisplay.MatrixOrbitalProtocol
{
    /// <summary>
    /// The commands.
    /// </summary>
    public enum Commands
    {
        /// <summary>
        /// Set Cursor Position
        /// </summary>
        SetCursorPosition = 71,

        /// <summary>
        /// Cursor Home
        /// </summary>
        CursorHome = 72,

        /// <summary>
        /// Underline Cursor On
        /// </summary>
        UnderlineCursorOn = 74,

        /// <summary>
        /// Underline Cursor Off
        /// </summary>
        UnderlineCursorOff = 75,

        /// <summary>
        /// Block Cursor On
        /// </summary>
        BlockCursorOn = 83,

        /// <summary>
        /// Block Cursor Off
        /// </summary>
        BlockCursorOff = 84,

        /// <summary>
        /// Move Cursor Left
        /// </summary>
        MoveCursorLeft = 76,

        /// <summary>
        /// Move Cursor Right
        /// </summary>
        MoveCursorRight = 77,

        /// <summary>
        /// Define Custom Character
        /// </summary>
        DefineCustomCharacter = 78,

        /// <summary>
        /// Read Serial Number
        /// </summary>
        ReadSerialNumber = 35,

        /// <summary>
        /// Read Version Number
        /// </summary>
        ReadVersionNumber = 36,

        /// <summary>
        /// Read Module Type
        /// </summary>
        ReadModuleType = 55,

        /// <summary>
        /// Set Contrast
        /// </summary>
        SetContrast = 80,

        /// <summary>
        /// Auto Scroll On
        /// </summary>
        AutoScrollOn = 81,

        /// <summary>
        /// Auto Scroll Off
        /// </summary>
        AutoScrollOff = 82,

        /// <summary>
        /// General Purpose Output Off
        /// </summary>
        GeneralPurposeOutputOff = 86,

        /// <summary>
        /// General Purpose Output On
        /// </summary>
        GeneralPurposeOutputOn = 87,

        /// <summary>
        /// Clear Screen
        /// </summary>
        ClearScreen = 88,

        /// <summary>
        /// Place Large Number
        /// </summary>
        PlaceLargeNumber = 35,

        /// <summary>
        /// Poll Key Presses
        /// </summary>
        PollKeyPresses = 38,

        /// <summary>
        /// Change I2c Slave Address
        /// </summary>
        ChangeI2CSlaveAddress = 51,

        /// <summary>
        /// Change Baud Rate
        /// </summary>
        ChangeBaudRate = 57,

        /// <summary>
        /// Exit Flow-Control Mode
        /// </summary>
        ExitFlowControlMode = 59,

        /// <summary>
        /// Place Vertical Bar
        /// </summary>
        PlaceVerticalBar = 61,

        /// <summary>
        /// Change The Startup Screen
        /// </summary>
        ChangeTheStartupScreen = 64,

        /// <summary>
        /// Auto Transmit Keypresses On
        /// </summary>
        AutoTransmitKeypressesOn = 65,

        /// <summary>
        /// Auto Line Wrap On
        /// </summary>
        AutoLineWrapOn = 67,

        /// <summary>
        /// Auto Line Wrap Off
        /// </summary>
        AutoLineWrapOff = 68,

        /// <summary>
        /// Backlight On
        /// </summary>
        BacklightOn = 66,

        /// <summary>
        /// Clear Key Buffer
        /// </summary>
        ClearKeyBuffer = 69,

        /// <summary>
        /// Backlight Off
        /// </summary>
        BacklightOff = 70,

        /// <summary>
        /// Auto Transmit Keypress Off
        /// </summary>
        AutoTransmitKeypressOff = 79,

        /// <summary>
        /// Set Debounce Time
        /// </summary>
        SetDebounceTime = 85,

        /// <summary>
        /// Auto Repeat Mode Off
        /// </summary>
        AutoRepeatModeOff = 96,

        /// <summary>
        /// Set And Save Brightness
        /// </summary>
        SetAndSaveBrightness = 152,

        /// <summary>
        /// Set Backlight Brightness
        /// </summary>
        SetBacklightBrightness = 153,

        /// <summary>
        /// Initialize Horizontal Bar
        /// </summary>
        InitializeHorizontalBar = 104,

        /// <summary>
        /// Initialize Medium Number
        /// </summary>
        InitializeMediumNumber = 109,

        /// <summary>
        /// Initialize Lange Numbers
        /// </summary>
        InitializeLangeNumbers = 110,

        /// <summary>
        /// Place Medium Numbers
        /// </summary>
        PlaceMediumNumbers = 111,

        /// <summary>
        /// Initialize Narrow Vertical Bar
        /// </summary>
        InitializeNarrowVerticalBar = 115,

        /// <summary>
        /// Initialize Wide Vertical Bar
        /// </summary>
        InitializeWideVerticalBar = 118,

        /// <summary>
        /// Place Horizontal Bar Graph
        /// </summary>
        PlaceHorizontalBarGraph = 124,

        /// <summary>
        /// Set Auto Repeat Mode
        /// </summary>
        SetAutoRepeatMode = 126,

        /// <summary>
        /// Set And Save Contrast
        /// </summary>
        SetAndSaveContrast = 145,

        /// <summary>
        /// Transmission Protocol Select
        /// </summary>
        TransmissionProtocolSelect = 160,

        /// <summary>
        /// Load Custom Characters
        /// </summary>
        LoadCustomCharacters = 192,

        /// <summary>
        /// Setting A Non-Standart Baudrate
        /// </summary>
        SettingANonStandartBaudrate = 164,

        /// <summary>
        /// Save Custom Character
        /// </summary>
        SaveCustomCharacter = 193,

        /// <summary>
        /// Save Startup Screen Custom Characters
        /// </summary>
        SaveStartupScreenCustomCharacters = 194,

        /// <summary>
        /// Set Startup Gpo State
        /// </summary>
        SetStartupGpoState = 195,

        /// <summary>
        /// Dallas 1-Wire
        /// </summary>
        DallasOneWire = 200,

        /// <summary>
        /// Byte to initialize display
        /// </summary>
        Init = 254
    }
}