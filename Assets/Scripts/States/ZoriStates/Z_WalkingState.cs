using UnityEngine;
using UnityEngine.AI;

public class Z_WalkingState : IZoriStates
{
    private PlayerController _player = null;
    private IA_Zori _self = null;
    private NavMeshAgent _agent = null;
    private Animator _animator = null;
    private AudioSource _audioSource = null;
    private AudioClip[] _audios = null;
    private float _viewField = 0;
    private Vector3 _destination = Vector3.zero;
    private float _timer = 0;
    private float _timeBeforeMoving = 2;
    private LayerMask _layerHit = 0;
    private int _i = 0;
    private bool _return = false;

    void IZoriStates.Init(IA_Zori self)
    {
        _self = self;
        _agent = self.Agent;
        _layerHit = self.Target;
        _animator = self.Animator;
        _audioSource = self.AudioSource;
        _audios = self.WalkingAudio;
        _viewField = self.ViewField;
        _player = self.Player;
    }

    void IZoriStates.Enter()
    {
        _timer = 0;

        if (_player == null)
        {
            _self.ChangeCurrentState(E_ZoriStates.KO);
        }

        GenerateDestination();
        //Sound & FX
        //SetAnim
    }

    void IZoriStates.Exit()
    {
        _timer = 0;
        _timeBeforeMoving = 0;

        //Sound & FX
        //SetAnim
    }

    void IZoriStates.Tick()
    {
        float diffBetweenAIAndDestination = Vector3.Distance(_self.transform.position, _destination);

        if (diffBetweenAIAndDestination <= 2)
        {
            _timer += 1 * Time.deltaTime;

            if (_timer >= _timeBeforeMoving)
            {
                GenerateDestination();
            }
        }

        if (_agent != null)
        {
            float angle = Mathf.Abs(Vector3.Angle(_player.transform.position - _self.transform.position, _self.transform.forward));

            if (angle < _viewField)
            {
                RaycastHit hit;

                bool isTrue = Physics.Raycast(_self.transform.position, _self.transform.forward, out hit, 100, _layerHit);

                if (isTrue == true)
                {
                    PlayerController player = hit.transform.GetComponent<PlayerController>();

                    if (player != null)
                    {
                        _self.ChangeCurrentState(E_ZoriStates.CHASING);
                    }
                }
            }
        }
    }

    private void GenerateDestination()
    {
        float x = Random.Range(-7, 7);
        float z = Random.Range(-5, 5);

        _destination = new Vector3(_self.transform.position.x + x, _self.transform.position.y, _self.transform.position.z + z);

        _agent.SetDestination(_destination);

        _timer = 0;
    }
}
