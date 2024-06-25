using System;

public class DisplayObject : PlayerRayCast
{
    public static event Action<string, bool> OnNameObject;

    private NameObject _nameObjectOld;
    public override void FixedUpdate()
    {
        base.FixedUpdate();
        if (_onRayCast)
        {
            _nameObjectOld.OutlineOn(false);
        }
        if (_nameObject != null)
        {
            _nameObjectOld = _nameObject;
            OnNameObject?.Invoke(_nameObjectOld.GetNameObject(),true);
            _nameObjectOld.OutlineOn(true);
            _onRayCast = true;
        }
        else
        {
            if (!_onRayCast)
            {
                return;
            }
            OnNameObject?.Invoke("", false);
            _nameObjectOld.OutlineOn(false);
            _nameObjectOld = null;
            _onRayCast = false;
        }
    }
}
