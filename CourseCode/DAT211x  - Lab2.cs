    /// <summary>
    ///  Microsoft: DAT211x Developing Intelligent Apps Lab 2 code.
    /// </summary>
    /// <param name="values"></param>
    /// <returns></returns>
    private string FormatRequestJSON(List<String> values)
    {
        int idCnt = 1;
        JObject rss =
            new JObject(
                new JProperty("documents",
                    new JArray(
                        from p in values
                        select new JObject(
                            new JProperty("id", idCnt++),
                            new JProperty("text", p)
                            ))));
        var x = rss.ToString();
        return x;

        // original Microsoft code :D
        
        //int idCounter = 1;
        //StringBuilder reqJSON = new StringBuilder();
        //reqJSON.Append("{\"documents\":[");
        //foreach (string item in values)
        //{
        //    reqJSON.Append("{\"id\":\"" + idCounter + "\",\"text\":\"" + item +
        //    "\"},");
        //    idCounter++;
        //}
        //reqJSON.Append("]}");
        //return reqJSON.ToString();
    }