using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    class AwardViewModel
    {
        public int RewardId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public static AwardViewModel ToModel(Awards award)
        {
            var model = new AwardViewModel();
            model.RewardId = award.Id;
            model.Title = award.Title;
            model.Description = award.Description;

            return model;
        }
    }
}
