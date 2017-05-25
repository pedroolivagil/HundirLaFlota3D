using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using UnityEngine;

public class User : MonoBehaviour, EntityGame {

    private bool flagActive;
    private long idUsuario;
    private string username;
    private string email;

    public long GetIdUsuario() {
        return idUsuario;
    }

    public void SetIdUsuario(long idUsuario) {
        this.idUsuario = idUsuario;
    }

    public string GetEmail() {
        return email;
    }

    public void SetEmail(string email) {
        this.email = email;
    }

    public string GetUserName() {
        return username;
    }

    public void SetUserName(string username) {
        this.username = username;
    }

    public bool GetFlagActive() {
        return flagActive;
    }

    public void SetFlagActive(bool flagActive) {
        this.flagActive = flagActive;
    }

    public bool importData(JsonData data) {
        bool retorno;
        if (data != null) {
            SetIdUsuario((int)data["id_user"]);
            SetUserName(data["username"].ToString());
            SetEmail(data["email"].ToString());
            SetFlagActive((bool)data["flag_active"]);
            retorno = true;
        } else {
            retorno = false;
        }
        return retorno;
    }
}
