using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCell
{
    interface Stack
    {
        List<Card> cards { get; set; }

        void Add(List<Card> cardsToAdd);

        int RemovableCards();

        List<Card> Remove(int num);



    }
}
