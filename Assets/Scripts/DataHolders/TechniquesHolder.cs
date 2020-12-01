using UnityEngine;

[CreateAssetMenu(fileName = "Technique Holder", menuName = "Zori/Techniques/Technique Holder")]
public class TechniquesHolder : ScriptableObject
{
    [SerializeField] private Techniques _techniqueA = null;
    [SerializeField] private Techniques _techniqueB = null;
    [SerializeField] private Techniques _techniqueC = null;
    [SerializeField] private Techniques _techniqueD = null;

    private Techniques _currentTechniqueA = null;
    private Techniques _currentTechniqueB = null;
    private Techniques _currentTechniqueC = null;
    private Techniques _currentTechniqueD = null;

    public Techniques TechniqueA { get => _techniqueA; }
    public Techniques TechniqueB { get => _techniqueB; }
    public Techniques TechniqueC { get => _techniqueC; }
    public Techniques TechniqueD { get => _techniqueD; }

    public void Init()
    {
        if (_techniqueA != null)
            _currentTechniqueA = Instantiate(_techniqueA);
        if (_techniqueB != null)
            _currentTechniqueB = Instantiate(_techniqueB);
        if (_techniqueC != null)
            _currentTechniqueC = Instantiate(_techniqueC);
        if (_techniqueD != null)
            _currentTechniqueD = Instantiate(_techniqueD);

        _currentTechniqueA?.Init();
        _currentTechniqueB?.Init();
        _currentTechniqueC?.Init();
        _currentTechniqueD?.Init();
    }

    public Techniques UpdateTechniqueA(Techniques technique)
    {
        _techniqueA = technique;
        _techniqueA.Init();

        return _techniqueA;
    }

    public Techniques UpdateTechniqueB(Techniques technique)
    {
        _techniqueB = technique;
        _techniqueB.Init();

        return _techniqueB;
    }

    public Techniques UpdateTechniqueC(Techniques technique)
    {
        _techniqueC = technique;
        _techniqueC.Init();

        return _techniqueC;
    }

    public Techniques UpdateTechniqueD(Techniques technique)
    {
        _techniqueD = technique;
        _techniqueD.Init();

        return _techniqueD;
    }
}
