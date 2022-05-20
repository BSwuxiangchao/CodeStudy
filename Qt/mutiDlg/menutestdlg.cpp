#include "menutestdlg.h"
#include "ui_menutestdlg.h"
#include "QMessageBox"

MenuTestDlg::MenuTestDlg(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MenuTestDlg)
{
    ui->setupUi(this);

    //创建新的动作
    QAction *openAc = new QAction(tr("&Open"),this);
    //添加图标
    QIcon icon(":/myImages/Pictures/f1.png");
    openAc->setIcon(icon);
    //创建快捷键
    openAc->setShortcut(QKeySequence(tr("Ctrl+o")));

    //

    //在文件菜单中设置新的动作
    ui->menu_File->addAction(openAc);
}

MenuTestDlg::~MenuTestDlg()
{
    delete ui;
}

void MenuTestDlg::on_action_N_triggered()
{
    QMessageBox::about(this,tr("tip"),tr("open one file"));
}

