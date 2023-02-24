using f29Reader.Textract;
using FluentAssertions;

namespace Testing.Textract;

public class UtilsTest
{
    [Test]
    public void FindCompleteWordByIndex()
    {
        var index = 0;
        foreach (var word in Provider.Extracter()._page.GetWords())
        {
            if (word.Text == "CANTIDAD") break;
            index++;
        }

        var text = Provider.Extracter().Words.ToList().FindCompleteWordByIndex(index);
        text.ConcatenarString().Should().Be("CANTIDAD FACTURAS EMITIDAS");
    }

    [Test]
    public void METHOD()
    {
        Provider.Extracter().Words.FindBySentence("TOTAL A PAGAR DENTRO DEL PLAZO LEGAL").Should().NotBeNull();
    }

    [Test]
    public void buscadorDePalabras()
    {
        var right = Provider.Extracter()._page.GetWords().Where(j => j.Text == "834.480");

        foreach (var word in right)
        {
            Console.WriteLine(word.BoundingBox.Right);
        }

        Console.WriteLine(right);
    }

    [Test]
    public void TestBoxCollideLefct()
    {
        var collide = new BoxNotCollide(
            Provider.Extracter().Words.ToList().FindWord("Glosa"),
            Provider.Extracter().Words.ToList().FindWord("CANTIDAD"),
            Provider.Extracter()._page.GetWords());

        collide.WithLeft().Verify().Should().BeFalse();
    }


    [Test]
    public void TestBoxCollide()
    {
        var collide = new BoxNotCollide(
            Provider.Extracter().Words.ToList().FindWord("Glosa"),
            Provider.Extracter().Words.ToList().FindWord("CANTIDAD"),
            Provider.Extracter()._page.GetWords());

        collide.WithLeft().Verify().Should().BeFalse();
    }
}