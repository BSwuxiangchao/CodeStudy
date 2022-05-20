#include "mainwindow.h"
#include "ui_mainwindow.h"
#include "showslot.h"
#include "logindlg.h"
#include "menutestdlg.h"

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    bChange = false;
}

MainWindow::~MainWindow()
{
    delete ui;
}


void MainWindow::on_btnNewDig_clicked()
{
    /*
    bChange = !bChange;
    if(bChange)
    {
        ui->btnNewDig->setText("zhongguo");
    }
    else
        ui->btnNewDig->setText("中国");
    */
    //ShowSlot slot ;
    //emit()
    //slot.show();
    LoginDlg *login =new LoginDlg(this);
    //非模态对话框 保证只有一个弹出
    login->setWindowModality(Qt::ApplicationModal);
    //login->setModal(true);
    //login->setAttribute(Qt::WA_ShowModal);

    login->show();

    //模态对话框
    //LoginDlg dlg;
    //dlg.exec();
}


void MainWindow::on_btnTestMenu_clicked()
{
    MenuTestDlg *dlg = new MenuTestDlg(this);
    dlg->setAttribute(Qt::WA_ShowModal);
    dlg->show();
}

