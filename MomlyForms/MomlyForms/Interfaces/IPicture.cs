using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MomlyForms
{
    public interface IPicture
    {
        Task<Stream> GetImageStreamAsync();    
    }
}
