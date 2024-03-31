﻿using AAEmu.Commons.Network;
using AAEmu.Game.Core.Network.Game;
using AAEmu.Game.Models.Game.Mails;

namespace AAEmu.Game.Core.Packets.G2C;

public class SCMailBodyPacket : GamePacket
{
    private readonly bool _isPrepare;
    private readonly bool _isSent;
    private readonly MailBody _body;
    private readonly bool _isOpenDateModified;
    private readonly CountUnreadMail _count;

    public SCMailBodyPacket(bool isPrepare, bool isSent, MailBody body, bool isOpenDateModified, CountUnreadMail count)
        : base(SCOffsets.SCMailBodyPacket, 5)
    {
        _isPrepare = isPrepare;
        _isSent = isSent;
        _body = body;
        _isOpenDateModified = isOpenDateModified;
        _count = count;
    }

    public override PacketStream Write(PacketStream stream)
    {
        stream.Write(_isPrepare);
        stream.Write(_isSent);
        _body.Write(stream);
        stream.Write(_isOpenDateModified);
        _count.Write(stream);
        return stream;
    }
}
