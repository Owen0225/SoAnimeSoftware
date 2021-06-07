using SoAnimeSoftware.GUI.Elements.Abstraction;

namespace SoAnimeSoftware.GUI.Elements
{
    public class StringSource : IDataSource
    {
        private string _data;

        public StringSource(string data)
        {
            this._data = data;
        }

        public string GetData()
        {
            return _data;
        }

        public void SetData(string data)
        {
            this._data = data;
        }
    }
}