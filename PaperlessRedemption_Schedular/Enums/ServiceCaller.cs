using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperlessRedemption_Schedular.Enums
{
    public enum ApiMethod
    {
        GET = 1,
        POST
    }

    public enum AuthenticationType
    {
        Basic = 1,
        Bearer
    }

    public enum ServiceType
    {
        STPTransactionSoapService
    }

    public enum ServiceCaller
    {
        Test = 1,
        ARMAutoMatch = 2,
        PaperlessRedemption_Scheduler
    }
    public enum DaysOfWeek
    {
        //
        // Summary:
        //     Indicates Sunday.
        Sunday = 0,
        //
        // Summary:
        //     Indicates Monday.
        Monday = 1,
        //
        // Summary:
        //     Indicates Tuesday.
        Tuesday = 2,
        //
        // Summary:
        //     Indicates Wednesday.
        Wednesday = 3,
        //
        // Summary:
        //     Indicates Thursday.
        Thursday = 4,
        //
        // Summary:
        //     Indicates Friday.
        Friday = 5,
        //
        // Summary:
        //     Indicates Saturday.
        Saturday = 6
    }
}
