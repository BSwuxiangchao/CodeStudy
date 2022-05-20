#include "logindlg.h"
#include "ui_logindlg.h"
#include "QMessageBox"

LoginDlg::LoginDlg(QWidget *parent) :
    QDialog(parent),
    ui(new Ui::LoginDlg)
{
    ui->setupUi(this);
}

LoginDlg::~LoginDlg()
{
    delete ui;
}

void LoginDlg::on_btnLogin_clicked()
{
//    if(ui->editPswd->text()=="5")
//        accept();
//    else
//    {
//        QMessageBox::warning(this,tr("waring"),tr("密码 5"),QMessageBox::Yes);
//    }
    accept();
}


void LoginDlg::on_btnCancle_clicked()
{
    close();
}

