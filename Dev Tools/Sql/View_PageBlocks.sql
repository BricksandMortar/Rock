SELECT 
	s.Name [Site.Name]
	,p.InternalName [Page.Title]
    ,p.[Guid] [Page.Guid]
    ,b.NAME [Block.Name]
    ,b.[Guid] [Block.Guid]
	,b.CreatedDateTime
    ,bt.NAME [BlockType.Name]
FROM [Block] [b]
JOIN [Page] [p] ON [p].[Id] = [b].[PageId]
JOIN [BlockType] [bt] ON [bt].[Id] = [b].[BlockTypeId]
JOIN [Layout] [l] ON p.LayoutId = l.Id
JOIN [Site] [s] ON l.SiteId = s.Id
ORDER BY s.Name desc, p.InternalName
    ,b.NAME

delete from [Block] where [Guid] = '601DDB93-555D-4E08-AAA3-EE0807BFD3E1'
delete from [Block] where [Guid] = 'E27EA67E-AB6E-4F61-A03B-D7697BBE922C'