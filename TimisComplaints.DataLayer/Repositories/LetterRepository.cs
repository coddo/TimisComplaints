using TimisComplaints.DataLayer.Repositories.Base;

namespace TimisComplaints.DataLayer.Repositories
{
    public class LetterRepository : BaseRepository<Letter>
    {
        public LetterRepository()
        {

        }

        public LetterRepository(Entities context) : base(context)
        {

        }
    }
}