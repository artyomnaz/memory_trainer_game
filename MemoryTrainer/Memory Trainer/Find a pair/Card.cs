using System.Windows.Forms;

namespace Memory_Trainer.Find_a_pair
{
    public class Card
    {
        private PictureBox openImage;
        private PictureBox closeImage;
        private bool isOpen { get; set; }
        private int imageType { get; set; }

        public Card(PictureBox openImage, PictureBox closeImage)
        {
            this.openImage = openImage;
            this.closeImage = closeImage;
        }
    }
}
