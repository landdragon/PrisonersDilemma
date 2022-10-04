using PrisonersDilemma;

namespace PrisonersDilemmaTest
{
    public class RulerTest
    {
        [Fact]
        public void BothSuspectStaysSilent()
        {
            var ruler = new Ruler();
            (ActionEnum Suspect1, ActionEnum Suspect2) interrogatoryResult = (ActionEnum.StaysSilent, ActionEnum.StaysSilent);
            var sentence = ruler.CalculateSentence(interrogatoryResult);

            Assert.Equal(-1, sentence.Suspect1);
            Assert.Equal(-1, sentence.Suspect2);
        }
        [Fact]
        public void Suspect1BetraysButSuspect2StaysSilent()
        {
            var ruler = new Ruler();
            (ActionEnum Suspect1, ActionEnum Suspect2) interrogatoryResult = (ActionEnum.Betrays, ActionEnum.StaysSilent);
            var sentence = ruler.CalculateSentence(interrogatoryResult);

            Assert.Equal(0, sentence.Suspect1);
            Assert.Equal(-10, sentence.Suspect2);
        }

        [Fact]
        public void Suspect2BetraysButSuspect1SayNothing()
        {
            var ruler = new Ruler();
            (ActionEnum Suspect1, ActionEnum Suspect2) interrogatoryResult = (ActionEnum.StaysSilent, ActionEnum.Betrays);
            var sentence = ruler.CalculateSentence(interrogatoryResult);

            Assert.Equal(-10, sentence.Suspect1);
            Assert.Equal(0, sentence.Suspect2);
        }

        [Fact]
        public void BothSuspectBetrays()
        {
            var ruler = new Ruler();
            (ActionEnum Suspect1, ActionEnum Suspect2) interrogatoryResult = (ActionEnum.Betrays, ActionEnum.Betrays);
            var sentence = ruler.CalculateSentence(interrogatoryResult);

            Assert.Equal(-5, sentence.Suspect1);
            Assert.Equal(-5, sentence.Suspect2);
        }
    }
}