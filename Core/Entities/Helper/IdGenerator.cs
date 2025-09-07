using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSID.Creator.NET;

namespace Acc.Core.Entities.Helper
{
    

    public static class IdGenerator
    {
        private static readonly Random _random = new Random();

        public static string GenerateCustomId()
        {                                                 //  /\
            //long tsid = TsidCreator.GetTsid256().ToLong();  


            var tsid = TsidCreator.GetTsid1024();/// 100;

            //   
            //int randomDigits = _random.Next(1000, 10000);   //
            //string combinedId = $"{tsid}{randomDigits}";   //
                                             //
            var res=tsid.ToLong();
            return res.ToString();
        }                                                 
                                                          
    }

    
}
