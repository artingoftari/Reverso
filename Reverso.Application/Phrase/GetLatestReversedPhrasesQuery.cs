using Azure;
using MediatR;
using Reverso.Application.Phrase.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverso.Application.Phrase
{
    public class GetLatestReversedPhrasesQuery : IRequest<List<PhraseViewModel>>
    {
        private int? page;
        private int? size;
        public int? Page
        {
            get
            {
                if (page == null || page < 1)
                {
                    page = 1;
                }
                return page;
            }
            set
            {
                page = value;
            }
        }
        public int? Size
        {
            get
            {
                if (size == null || size < 1)
                {
                    size = 5;
                }
                if (size > 50)
                {
                    size = 50;
                }
                return size;
            }
            set
            {
                size = value;
            }
        }
    }
}
