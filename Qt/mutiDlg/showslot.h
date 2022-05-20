#ifndef SHOWSLOT_H
#define SHOWSLOT_H

#include <QDialog>

namespace Ui {
class ShowSlot;
}

class ShowSlot : public QDialog
{
    Q_OBJECT

public:
    explicit ShowSlot(QWidget *parent = nullptr);
    ~ShowSlot();

private:
    Ui::ShowSlot *ui;
};

#endif // SHOWSLOT_H
