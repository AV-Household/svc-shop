namespace svc_shop.Models
{

    public record FamilyMember
    (
        Guid Id,
        string EMail,
        string Phone,
        string Name,
        bool IsAdult
    );
}