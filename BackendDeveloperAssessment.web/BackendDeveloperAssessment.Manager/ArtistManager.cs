using BackendDeveloperAssessment.IRepository;
using BackendDeveloperAssessment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendDeveloperAssessment.Manager
{
    public class ArtistManager
    {

        IArtistRepository artistRepository;
        IAliasRepository aliasRepository;

        public ArtistManager(IArtistRepository artistRepository, IAliasRepository aliasRepository)
        {
            this.artistRepository = artistRepository;
            this.aliasRepository = aliasRepository;
        }

        public List<ArtistDisplayViewModel> GetAll()
        {
            List<ArtistDisplayViewModel> artistDisplayViewModelList = new List<ArtistDisplayViewModel>();
            var artists = artistRepository.GetAll().ToList();

            foreach (var artist in artists)
            {
                ArtistDisplayViewModel artistDisplayViewModel = new ArtistDisplayViewModel();

                artistDisplayViewModel.Name = artist.ArtistName;
                artistDisplayViewModel.Country = artist.Country;
                artistDisplayViewModel.Alias = ConvertAliasToStringList(aliasRepository.GetByArtistId(artist.ArtistId));

                artistDisplayViewModelList.Add(artistDisplayViewModel);
            }
            return artistDisplayViewModelList;
        }

        public List<ArtistDisplayViewModel> Search(List<ArtistDisplayViewModel> results, string searchCriteria, int pageNumber, int pageSize)
        {
            return null;// artistRepository.GetAll().Where(x => x.ArtistName.ToLower().Contains(searchQuery.ToLower())).ToList();
        }

        private List<string> ConvertAliasToStringList(List<Aliases> aliasList)
        {
            List<string> strList = new List<string>();

            foreach (var alias in aliasList)
            {
                strList.Add(alias.AliasName);
            }

            return strList;
        }
    }
}
