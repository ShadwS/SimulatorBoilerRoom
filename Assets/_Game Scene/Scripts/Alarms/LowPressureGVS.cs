public class LowPressureGVS : Alarm
{
    //Проверить уровень воды в баке запаса воды
    //Проверить работоспособность насосов подпитки
    //Проверить(при необходимости прокачать) расширительный бак
    //Проверить на утечку, систему отопления
    //Проверить показания датчика давления
    //private string _nameAlarm = "Низкий давление в GVS";

    protected override void Start()
    {
        base.Start();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }

    protected override void UpdateInteractionSelect(InteractionInformation interactionSelect)
    {
        base.UpdateInteractionSelect(interactionSelect);
    }

    protected override void CorrectObject()
    {
        base.CorrectObject();
    }

    protected override void ButtonClick(int nomerButton)
    {
        base.ButtonClick(nomerButton);
    }

    protected override void InteractionInfoTextColorUpdate(bool value)
    {
        base.InteractionInfoTextColorUpdate(value);
    }

    protected override void ViktoryChek()
    {
        base.ViktoryChek();
    }

    protected override void ButtonActionClick()
    {
        base.ButtonActionClick();
    }
}
