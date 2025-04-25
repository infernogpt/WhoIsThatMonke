using System;

namespace WhoIsThatMonke
{
    internal class PublicVariablesGatherHere
    {
        // Backing fields
            // Module bools
            private static bool _isPlatformEnabled = true;
            private static bool _isColorCodeEnabled = true;
            private static bool _isVelocityEnabled = true;
            private static bool _isFPSEnabled = true;

            // Module setting bools
            private static bool _twoFiftyFiveColorCodes = false;

        // Central event
        public static event Action BoolChangedButOnlyTheGoodOnes;

        public static bool isPlatformEnabled
        {
            get => _isPlatformEnabled;
            set
            {
                if (_isPlatformEnabled != value)
                {
                    _isPlatformEnabled = value;
                    BoolChangedButOnlyTheGoodOnes?.Invoke();
                }
            }
        }

        public static bool isColorCodeEnabled
        {
            get => _isColorCodeEnabled;
            set
            {
                if (_isColorCodeEnabled != value)
                {
                    _isColorCodeEnabled = value;
                    BoolChangedButOnlyTheGoodOnes?.Invoke();
                }
            }
        }

        public static bool isVelocityEnabled
        {
            get => _isVelocityEnabled;
            set
            {
                if (_isVelocityEnabled != value)
                {
                    _isVelocityEnabled = value;
                    BoolChangedButOnlyTheGoodOnes?.Invoke();
                }
            }
        }

        public static bool isFPSEnabled
        {
            get => _isFPSEnabled;
            set
            {
                if (_isFPSEnabled != value)
                {
                    _isFPSEnabled = value;
                    BoolChangedButOnlyTheGoodOnes?.Invoke();
                }
            }
        }

        public static bool twoFiftyFiveColorCodes
        {
            get => _twoFiftyFiveColorCodes;
            set
            {
                if (_twoFiftyFiveColorCodes != value)
                {
                    _twoFiftyFiveColorCodes = value;
                    BoolChangedButOnlyTheGoodOnes?.Invoke();
                }
            }
        }
    }
}
