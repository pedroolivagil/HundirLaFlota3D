using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* Response codes:
*  - 200: Connection successfull and return expected data
*  - 404: Connection successfull and return fail data
*  
*  - 400: Connection unsuccessfull
*/
public class ExceptionGame {

    public enum ResponseCode {
        CODE_100, CODE_200, CODE_400, CODE_404
    }

    public ResponseCode code;
    public string message;

    public ExceptionGame(ResponseCode code, string message) {
        this.code = code;
        this.message = message;
    }
}
