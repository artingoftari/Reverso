using Reverso.Application.Phrase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reverso.Application.Tests
{
    public class GetLatestReversedPhrasesQueryTests
    {
        [Fact]
        public void NewQuery_SizeExceeds50_CapsSizeTo50()
        {
            GetLatestReversedPhrasesQuery query = new GetLatestReversedPhrasesQuery { Size = 100 };

            Assert.Equal(50, query.Size);
        }
        [Fact]
        public void NewQuery_SizeAndPageNotGiven_GetsDefaultValues()
        {
            GetLatestReversedPhrasesQuery query = new();

            Assert.Equal(1, query.Page);
            Assert.Equal(5, query.Size);
        }
    }
}
