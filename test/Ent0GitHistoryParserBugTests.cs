using System;
using System.IO;
using NUnit.Framework;
using ThoughtWorks.CruiseControl.Core;
using ThoughtWorks.CruiseControl.Core.Sourcecontrol;

namespace test
{
	[TestFixture]
	public class Ent0GitHistoryParserBugTests
	{
		[Test]
		public void SouldShowMergeCommits()
		{
			Ent0GitHistoryParser parser = new Ent0GitHistoryParser();
			string commitHistory =
				@"
Commit:92b92bd9ff2e760a4b03d21a04ac0e7ac3059d04
Time:2009-12-11 14:58:37 -0500
Author:devpair2
E-Mail:devpair2@arpc.com
Message:Merge remote branch 'remotes/origin/FIX_ClaimFormPrint' into integration


Changes:
Commit:49e5786b6c7632bbefd2e11ceca6efe202a8accb
Time:2009-12-11 14:36:07 -0500
Author:devpair08
E-Mail:devpair08@arpc.com
Message:MCKJ - Fixed issue with the ClaimFormService not returning a correct formatter and introduced the HWS claim print form.


Changes:
M	TrustOnline.Business/Services/ClaimFormService.cs
M	TrustOnline/sc/claimformprint/hals.html
A	TrustOnline/sc/claimformprint/hws.html

Commit:41573c7325336700f230c2d11d174dfafa53197d
Time:2009-12-11 14:09:42 -0500
Author:devpair08
E-Mail:devpair08@arpc.com
Message:MCKJ - Updating claimview.css to properly display a HALS claim form.


Changes:
M	TrustOnline/sc/claimview.css

Commit:6072b7fdcc571d31814d6d08ce6042d75f3dad62
Time:2009-12-11 11:51:54 -0500
Author:SB
E-Mail:ent0pair11@hotmail.com
Message:Merge commit 'origin/FIX_11061_ExtraDeficiencyCode' into integration


Changes:
Commit:9107910327f073bbb78b70a4024a99664fce66cf
Time:2009-12-11 11:51:37 -0500
Author:SB
E-Mail:ent0pair11@hotmail.com
Message:Merge commit 'origin/FIX_FB11057_DefCode170NewText' into integration


Changes:
Commit:3ad68c3dae229fbb4f3e14d4bc6324115a6b4df6
Time:2009-12-11 11:49:47 -0500
Author:SB
E-Mail:ent0pair11@hotmail.com
Message:SBPM -- Fixing DII Silica deficiency codes per case. BugzId: 11061


Changes:
M	TrustOnline.Business/Database/Maps/DeficiencyCode.sql

Commit:bec26cb79deebe8afb139d4417f521416954d61d
Time:2009-12-11 11:20:51 -0500
Author:SB
E-Mail:ent0pair11@hotmail.com
Message:SBPM -- Project File fix


Changes:
M	TrustOnline.Business/TrustOnline.Business.csproj

Commit:180dad8ef06bf88aae38b96ecacf3ad9dcb3899b
Time:2009-12-11 11:19:46 -0500
Author:SB
E-Mail:ent0pair11@hotmail.com
Message:Merge commit 'origin/FIX_FB11055_DIIA_NODA_Letters' into integration


Changes:
Commit:64493fc719268b38a28039c216b3a70fd4484e95
Time:2009-12-11 11:19:35 -0500
Author:SB
E-Mail:ent0pair11@hotmail.com
Message:Merge commit 'origin/FIX_FB11052_ClaimLog' into integration


Changes:
Commit:0fa8f4b93453e25306f8978e11bf433d959dde84
Time:2009-12-11 11:19:14 -0500
Author:SB
E-Mail:ent0pair11@hotmail.com
Message:SBPM -- Merging FIX_10813 into Integration


Changes:
Commit:515e8c09010c1163a43a4a40d36c67c86c7011ea
Time:2009-12-11 10:29:07 -0500
Author:PMAF
E-Mail:devpair00@arpc.com
Message:BSKK - 11057.1 - Update long text fields for deficiency code 170. BugzID: 11057


Changes:
M	TrustOnline.Business/Database/Maps/DeficiencyCode.sql

Commit:b67a3b1eaeab71eea8b5a23dccd3b054c30d1fc9
Time:2009-12-10 15:45:00 -0500
Author:devpair01
E-Mail:devpair01@arpc.com
Message:SBJB -- Updating DIIA NODA reports with new address in footer. BugzID: 11055


Changes:
M	TrustOnline.Reports/HAL_Release.rdl
M	TrustOnline.Reports/HW_Release.rdl

Commit:dcd41125b38f4475a089ff777362571e6e6bbb0f
Time:2009-12-10 15:02:20 -0500
Author:devpair2
E-Mail:devpair2@arpc.com
Message:BSAD - Fixed hard-coded trust id value. BugzID: 11052


Changes:
M	TrustOnline.Business/Services/ClaimHistoryLogFormater.cs
M	UnitTests.TrustOnline.Fast/Services/ClaimHistoryLogFormaterTests.cs

Commit:ac0b94f93a628c97f0fe1d6ddf43875fbb7e9702
Time:2009-12-10 14:59:45 -0500
Author:PMAF
E-Mail:devpair00@arpc.com
Message:PMAF - Fix to processinjuryxref load to fix problem with alleged injury not correctly copying over during conversion between trusts. BugzID: 10813


Changes:
M	TrustOnline.Business/Database/deltas/1.0/09000.sql

Commit:307a9517643c85ddbe7369af96b56b7cf912e352
Time:2009-12-10 13:19:54 -0500
Author:PMAF
E-Mail:devpair00@arpc.com
Message:PMAF - Fixing conversion problems with new DIIS trusts (HALS and HWS) BugzID: 10813


Changes:
A	TrustOnline.Business/Database/deltas/1.0/09000.sql
M	TrustOnline.Business/TrustOnline.Business.csproj
M	UnitTests.TrustOnline.Business/TrustSetup/TrustSetupTests_ACS.cs
";
			Modification[] modifications = parser.Parse(new StringReader(commitHistory), 12212);
			Assert.AreEqual(15, modifications.Length);

		}
	}
}
