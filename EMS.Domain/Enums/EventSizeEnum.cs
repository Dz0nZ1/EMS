using Ardalis.SmartEnum;

namespace EMS.Domain.Enums;

public abstract class EventSizeEnum : SmartEnum<EventSizeEnum>
{

    public static EventSizeEnum Small = new SmallEventSizeEnum();
    public static EventSizeEnum Medium = new MediumEventSizeEnum();
    public static EventSizeEnum Big = new BigEventSizeEnum();

    public abstract int MaxNumberOfPeople { get; }
    
    
    protected EventSizeEnum(string name, int value) : base(name, value)
    {
    }
    
    private sealed class SmallEventSizeEnum : EventSizeEnum
    {
        public SmallEventSizeEnum() : base(nameof(Small), 1)
        {
        }

        public override int MaxNumberOfPeople => 25;
    }
    
    
    private sealed class MediumEventSizeEnum : EventSizeEnum
    {
        public MediumEventSizeEnum() : base(nameof(Medium), 2)
        {
        }

        public override int MaxNumberOfPeople => 50;
    }
    
    
    private sealed class BigEventSizeEnum : EventSizeEnum
    {
        public BigEventSizeEnum() : base(nameof(Big), 1)
        {
        }

        public override int MaxNumberOfPeople => 100;
    }
    
}