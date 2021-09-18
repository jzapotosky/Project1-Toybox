public class Character
{
    private string _firstName = "";
    private string _lastName = "";
    private char _middleInitial = '';
    private int _age = 0;
    private bool _married = true;
    private float _height = 3.14159f;
    
    public Character()
    {
        
    }

    public Character (string firstName, string lastName, char middleInitial, bool married, float height )
    {
        _firstName = firstName;
        _lastName = lastName;
        _middleInitial = middleInitial;
        _married = married;
        _height = height;
    }

}
