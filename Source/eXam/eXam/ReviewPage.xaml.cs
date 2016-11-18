using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace eXam
{
    public partial class ReviewPage : ContentPage
    {
        public ReviewPage()
        {
            InitializeComponent();

            lblResult.Text = String.Format("Great! You got {0} out of {1} questions correct", App.CurrentGame.GetNumberOfCorrectResponses(), App.CurrentGame.NumberOfQuestions);
        }
    }
}
