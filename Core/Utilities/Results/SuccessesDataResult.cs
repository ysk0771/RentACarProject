using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
   public class SuccessesDataResult<T>:DataResult<T>
    {
        public SuccessesDataResult(T data,string message):base(data,true,message)
        {

        }

        public SuccessesDataResult(T data):base(data,true)
        {

        }

        public SuccessesDataResult(string message):base(default,true,message)
        {

        }

        public SuccessesDataResult():base(default,true)
        {

        }
    }
}
