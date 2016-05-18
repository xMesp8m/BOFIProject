using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using Ploeh.AutoFixture.Xunit2;

namespace BOFI.Tests.Infraestructure
{
    public class AutoFixtureMoqAutoDataAttribute : AutoDataAttribute
    {
        public AutoFixtureMoqAutoDataAttribute() :
            base(new Fixture().Customize(new AutoMoqCustomization()))
        {
        }
    }
}
