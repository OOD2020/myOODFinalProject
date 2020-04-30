/* #############################
 * 
 * Author: Johnathon Mc Grory
 * Date : 1/05/2020
 * Description : C# Code for Object Orientated Development for Final End Of Year Project 
 * 
 * ############################# */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace last_time
{
    public partial class Drinks
    {
        public override string ToString()
        {
            return string.Format("{0,-25}{1, -25:C}", this.Name, this.Cost);
        }
    }
}
