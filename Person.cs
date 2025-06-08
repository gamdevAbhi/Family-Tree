namespace FamilyTree;

public class Person
{
    public enum Gender { Male, Female }

    internal string name;
    internal Gender gender;

    public Person(string name, Gender gender)
    {
        this.name = name;
        this.gender = gender;
    }
}