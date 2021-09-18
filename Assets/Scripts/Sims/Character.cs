public class Character
{
    private string _firstName = "";
    public string FirstName => _firstName;

    private string _lastName = "";
    public string LastName => _lastName;

    private char _middleInitial = '\0';
    public char MiddleInitial => _middleInitial;

    private int _age = 0;
    public int Age => _age;

    private bool _married = true;
    public bool Married => _married;

    private float _height = 3.14159f;
    public float Height => _height;
    
    public Character()
    {
        
    }

    public Character(string firstName, string lastName, char middleInitial, int age, bool married, float height )
    {
        _firstName = firstName;
        _lastName = lastName;
        _middleInitial = middleInitial;
        _age = age;
        _married = married;
        _height = height;
    }

}
