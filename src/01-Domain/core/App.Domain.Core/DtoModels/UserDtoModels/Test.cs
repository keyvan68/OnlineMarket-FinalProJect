using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels.UserDtoModels
{
    abstract class Test
    {
        public abstract void TEst3();
        public void Test2()
        {

        }
    }
    class test1 : Test
    {
        public override void TEst3()
        {
            throw new NotImplementedException();
        }
    }
}
