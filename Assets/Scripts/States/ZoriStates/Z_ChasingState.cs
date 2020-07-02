using UnityEngine;
using UnityEngine.AI;

public class Z_ChasingState : IZoriStates
{
    private PlayerController _player = null;
    private IA_Zori _self = null;
    private NavMeshAgent _agent = null;
    private Animator _animator = null;
    private AudioSource _audioSource = null;
    private AudioClip[] _audios = null;
    private float _viewField = 0;

    void IZoriStates.Init(IA_Zori self)
    {
        _self = self;
        _agent = self.Agent;
        _animator = self.Animator;
        _audioSource = self.AudioSource;
        _audios = self.ChasingAudio;
        _viewField = self.ViewField;
        _player = self.Player;
    }

    void IZoriStates.Enter()
    {
        if(_player == null)
        {
            _self.ChangeCurrentState(E_ZoriStates.KO);
        }

        _agent.speed += 5;
        _agent.stoppingDistance = 4;
    }

    void IZoriStates.Exit()
    {
        _agent.isStopped = true;
    }

    void IZoriStates.Tick()
    {
        float distFromPlayer = Vector3.Distance(_self.transform.position, _agent.destination);

        _agent.SetDestination(_player.transform.position);

        if (_agent != null)
        {
            float angle = Mathf.Abs(Vector3.Angle(_player.transform.position - _self.transform.position, _self.transform.forward));

            if (angle > _viewField)
            {
                _self.ChangeCurrentState(E_ZoriStates.WALKING);
            }
        }

        if (distFromPlayer < _agent.stoppingDistance)
        {
            _self.ChangeCurrentState(E_ZoriStates.BATTLE);
        }
    }
}