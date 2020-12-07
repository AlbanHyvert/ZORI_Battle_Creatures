using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Technique Holder", menuName = "Zori/Techniques/Technique Holder")]
public class TechniquesHolder : ScriptableObject
{
    [SerializeField] private Techniques _techniqueA = null;
    [SerializeField] private Techniques _techniqueB = null;
    [SerializeField] private Techniques _techniqueC = null;
    [SerializeField] private Techniques _techniqueD = null;

    private List<Techniques> _currentTechniques = new List<Techniques>();

    public List<Techniques> CurrentTechniques { get => _currentTechniques; }

    public void Init()
    {
        if (_techniqueA != null)
            _currentTechniques.Add(Instantiate(_techniqueA));
        if (_techniqueB != null)
            _currentTechniques.Add(Instantiate(_techniqueB));
        if (_techniqueC != null)
            _currentTechniques.Add(Instantiate(_techniqueC));
        if (_techniqueD != null)
            _currentTechniques.Add(Instantiate(_techniqueD));

        for (int i = 0; i < _currentTechniques.Count; i++)
        {
            if (_currentTechniques[i])
                _currentTechniques[i].Init();
        }

        Debug.Log(CheckTechniqueQuantity());
    }

    public int CheckTechniqueQuantity()
    {
        int index = 0;

        for (int i = 0; i < _currentTechniques.Count; i++)
        {
            if (_currentTechniques[i])
                index++;
        }

        return index;
    }

    public Techniques UpdateTechniqueA(Techniques technique)
    {
        _currentTechniques[0] = technique;
        _currentTechniques[0].Init();

        return _currentTechniques[0];
    }

    public Techniques UpdateTechniqueB(Techniques technique)
    {
        _currentTechniques[1] = technique;
        _currentTechniques[1].Init();

        return _currentTechniques[1];
    }

    public Techniques UpdateTechniqueC(Techniques technique)
    {
        _currentTechniques[2] = technique;
        _currentTechniques[2].Init();

        return _currentTechniques[2];
    }

    public Techniques UpdateTechniqueD(Techniques technique)
    {
        _currentTechniques[3] = technique;
        _currentTechniques[3].Init();
        
        return _currentTechniques[3];
    }
}
