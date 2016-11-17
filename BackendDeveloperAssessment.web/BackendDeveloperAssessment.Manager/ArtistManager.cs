using BackendDeveloperAssessment.IRepository;
using BackendDeveloperAssessment.IRepository.IUtilities;
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
        IPagerUtility<ArtistDisplayViewModel> pagerUtility;

        public ArtistManager(IArtistRepository artistRepository, IAliasRepository aliasRepository, IPagerUtility<ArtistDisplayViewModel> pagerUtility)
        {
            this.artistRepository = artistRepository;
            this.aliasRepository = aliasRepository;
            this.pagerUtility = pagerUtility;
        }

        private List<ArtistDisplayViewModel> GetAll(string searchCriteria = "")
        {
            List<ArtistDisplayViewModel> artistDisplayViewModelList = new List<ArtistDisplayViewModel>();
            var artists = artistRepository.GetAll().ToList();

            foreach (var artist in artists)
            {
                ArtistDisplayViewModel artistDisplayViewModel = new ArtistDisplayViewModel();

                artistDisplayViewModel.Name = artist.ArtistName;
                artistDisplayViewModel.Country = artist.Country;
                artistDisplayViewModel.Alias = ConvertAliasToStringList(aliasRepository.GetByArtistId(artist.ArtistId).ToList());

                if (artistDisplayViewModel.Name.ToLower().Contains(searchCriteria) || SearchStrArray(artistDisplayViewModel.Alias, searchCriteria))
                {
                    artistDisplayViewModelList.Add(artistDisplayViewModel);
                }
            }
            return artistDisplayViewModelList;
        }

        public int GetAllCount(string searchCriteria)
        {
            return GetAll(searchCriteria).Count;
        }

        public List<ArtistDisplayViewModel> Search(string searchCriteria, int pageNumber, int pageSize)
        {
            return pagerUtility.GetPageItems(GetAll(searchCriteria), pageNumber, pageSize).ToList();
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

        private bool SearchStrArray(List<string> strArray, string searchCriteria)
        {
            foreach (string x in strArray)
            {
                if (x.ToLower().Contains(searchCriteria.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
