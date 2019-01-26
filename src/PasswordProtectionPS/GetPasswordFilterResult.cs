﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Security;
using Lithnet.ActiveDirectory.PasswordProtection;

namespace Lithnet.ActiveDirectory.PasswordProtection.PowerShell
{
    [Cmdlet(VerbsCommon.Get, "PasswordFilterResult", DefaultParameterSetName = "String")]
    public class GetPasswordFilterResult : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true, ParameterSetName = "String"), ValidateNotNullOrEmpty]
        public string Password { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true, ParameterSetName = "SecureString"), ValidateNotNullOrEmpty]
        public SecureString SecurePassword { get; set; }

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true), ValidateNotNullOrEmpty]
        public string Username { get; set; }

        [Parameter(Mandatory = true, Position = 3, ValueFromPipeline = true), ValidateNotNullOrEmpty]
        public string Fullname { get; set; }

        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false), ValidateNotNullOrEmpty]
        public bool IsSetOperation { get; set; }

        protected override void BeginProcessing()
        {
            Global.OpenExistingDefaultOrThrow();
            base.BeginProcessing();
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
        }

        protected override void ProcessRecord()
        {
            this.WriteObject(FilterInterface.TestPassword(this.Username, this.Fullname, this.ParameterSetName == "String" ? this.Password : this.SecurePassword.SecureStringToString(), this.IsSetOperation));
        }
    }
}
