using System.Collections.Generic;
using System.Threading.Tasks;
using TimisComplaints.DataLayer;
using TimisComplaints.DataLayer.Repositories;

namespace TimisComplaints.BusinessLogicLayer.Core
{
    public static class LetterCore
    {
        public static async Task<IList<Letter>> GetAllAsync()
        {
            using (var letterRepository = new LetterRepository())
            {
                return await letterRepository.GetAllAsync();
            }
        }

        public static async Task<Letter> CreateAsync(Letter letter)
        {
            using (var letterRepository = new LetterRepository())
            {
                return await letterRepository.CreateAsync(letter);
            }
        }
    }
}