using AngleSharp.Html.Parser;
using System;
using System.Threading.Tasks;
using TestTaskParser.Interfaces;

namespace TestTaskParser.Core
{
    public class Manager<T> where T : class
    {
        public IParser<T> Parser { get; set; }
        public HtmlLoader Loader { get; set; }

        private bool _isActive;

        public bool IsActive
        {
            get
            {
                return _isActive;
            }
        }

        public event Action<object, T> OnNewData;
        public event Action<object> OnCompleted;

        public Manager(IParser<T> parser)
        {
            Parser = parser;
        }

        public Manager(IParser<T> parser, IClientSettings parserSettings) : this(parser)
        {
            Loader = new HtmlLoader(parserSettings);
        }

        public async Task Start()
        {
            _isActive = true;
            await Worker();
        }

        public void Abort()
        {
            _isActive = false;
        }

        private async Task Worker()
        {
            if (!_isActive)
            {
                OnCompleted?.Invoke(this);
                return;
            }

            var source = await Loader.GetRequest();
            var domParser = new HtmlParser();
            var document = await domParser.ParseDocumentAsync(source.Message);
            var result = Parser.Parse(document);

            OnNewData?.Invoke(this, result);
            OnCompleted?.Invoke(this);
            _isActive = false;
        }

    }
}
