#ifndef MENUTESTDLG_H
#define MENUTESTDLG_H

#include <QMainWindow>

namespace Ui {
class MenuTestDlg;
}

class MenuTestDlg : public QMainWindow
{
    Q_OBJECT

public:
    explicit MenuTestDlg(QWidget *parent = nullptr);
    ~MenuTestDlg();

private slots:
    void on_action_N_triggered();

private:
    Ui::MenuTestDlg *ui;
};

#endif // MENUTESTDLG_H
