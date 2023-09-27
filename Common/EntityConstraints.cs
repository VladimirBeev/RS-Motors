namespace Common
{
    public static class EntityConstraints
    {

        public static  class CarConstraints
        {

            public const int ManufacturerMinLength = 2;
            public const int ManufacturerMaxLength = 50;

            public const int ModelMinLength = 2;
            public const int ModelMaxLength = 50;

            public const int YearMinLength = 4;
            public const int YearMaxLength = 4;

            public const int VinMinLength = 17;
            public const int VinMaxLength = 17;

            public const int RegistrationPlateMinLength = 3;
            public const int RegistrationPlateMaxLength = 20;

        }


        public static class CustomerConstraints
        {
            public const int FirstNameMinLength = 3;
            public const int FirstNameMaxLength = 100;

            public const int LastNameMinLength = 3;
            public const int LastNameMaxLength = 100;

            public const int AddressMinLength = 5;
            public const int AddressMaxLength = 50;

            public const int EmailMinLength = 5;
            public const int EmailMaxLength = 50;

            public const int PhoneMinLength = 5;
            public const int PhoneMaxLength = 50;
        }

        public static class PaymentConstraints
        {
            public const int CustomerNameMinLength = 3;
            public const int CustomerNameMaxLength = 100;

            public const int PaymentMethodMinLength = 3;
            public const int PaymentMethodMaxLength = 100;

        }

        public static class RepairPartConstraints
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 100;

            public const int DescriptionMinLength = 3;
            public const int DescriptionMaxLength = 2000;
        }
    }
}
