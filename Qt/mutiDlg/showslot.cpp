#include "showslot.h"
#include "ui_showslot.h"

ShowSlot::ShowSlot(QWidget *parent) :
    QDialog(parent),
    ui(new Ui::ShowSlot)
{
    ui->setupUi(this);
}

ShowSlot::~ShowSlot()
{
    delete ui;
}
