namespace FamilyTree;

public class Tree
{
    internal Person offspring;
    internal Person? spouse;
    internal List<Tree> childTrees;

    public Tree(Person offspring)
    {
        this.offspring = offspring;
        this.spouse = null;

        childTrees = new List<Tree>();
    }

    public Tree(Person offspring, Person? spouse)
    {
        this.offspring = offspring;
        this.spouse = spouse;

        childTrees = new List<Tree>();
    }

    public Tree(Person offspring, Person? spouse, List<Tree> childTrees)
    {
        this.offspring = offspring;
        this.spouse = spouse;

        this.childTrees = childTrees;
    }

    public void AddChildTree(Tree childTree)
    {
        if (childTrees.Contains(childTree)) return;

        childTrees.Add(childTree);
    }
}