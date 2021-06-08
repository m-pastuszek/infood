using System.IO;

namespace InFood.Interfejsy
{
    public interface IXmlStorage
    {
        bool FromXml(Stream Stream);
        MemoryStream ToXml();
    }
}
