﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


[Serializable]
public class Session
{

	public string Server, schemaname, username, password, port;
	public bool SslMode;


}