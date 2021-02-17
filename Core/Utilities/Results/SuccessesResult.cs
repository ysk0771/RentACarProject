using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
  public  class SuccessesResult:Result
    {
        public SuccessesResult(string message) : base(true, message)
        {

        }
        public SuccessesResult():base(true)
        { 
        
        }

    }
}
