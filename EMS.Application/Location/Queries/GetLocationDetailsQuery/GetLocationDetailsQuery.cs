using EMS.Application.Common.Dto.Location;
using MediatR;

namespace EMS.Application.Location.Queries.GetLocationDetailsQuery;

public record GetLocationDetailsQuery(string LocationId) : IRequest<LocationDetailsDto?>;