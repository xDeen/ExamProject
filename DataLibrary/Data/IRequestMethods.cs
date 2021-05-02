using DataLibrary.Models;
using System.Collections.Generic;

namespace DataLibrary.Data
{
    public interface IRequestMethods
    {
        List<Output> GetMatsRawMats(decimal qty);
        List<Output> GetMatsThree(decimal qty);
        List<Output> GetMatsTwo(decimal qty);
    }
}