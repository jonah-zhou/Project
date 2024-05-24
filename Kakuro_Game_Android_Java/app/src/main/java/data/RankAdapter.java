package data;

import android.content.Context;
import android.content.Intent;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import com.example.kakuro_game_android.GamePlayActivity;
import com.example.kakuro_game_android.R;
import com.example.kakuro_game_android.RankActivity;

import java.util.ArrayList;

import model.GamePlay;
import model.Record;

public class RankAdapter extends BaseAdapter {
    private Context context;

    private ArrayList<Record> rankList;
    public RankAdapter(Context context, ArrayList<Record> rankList){
        this.context = context;
        this.rankList = rankList;
    }

    @Override
    public int getCount() {
        return rankList.size();
    }

    @Override
    public Object getItem(int position) {
        return rankList.get(position);
    }

    @Override
    public long getItemId(int position) {
        return position;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        View oneItem = null;
        TextView txtRank, txtName, txtEmail, txtMistake, txtRepetition;

        LayoutInflater inflater = LayoutInflater.from(context);
        oneItem = inflater.inflate(R.layout.rank_item, (ViewGroup) convertView,false);

        txtRank = oneItem.findViewById(R.id.txtRank);
        txtName = oneItem.findViewById(R.id.txtName);
        txtEmail = oneItem.findViewById(R.id.txtEmail);
        txtMistake = oneItem.findViewById(R.id.txtMistake);
        txtRepetition = oneItem.findViewById(R.id.txtRepetition);
        final Record currentRecord = (Record) getItem(position);
        txtRank.setText("# " + (position + 1));
        txtName.setText(currentRecord.getPlayer().getPlayerName());
        txtEmail.setText(currentRecord.getPlayer().getAccount().getEmail());
        txtMistake.setText("Mistake: " + String.valueOf(currentRecord.getMistake()));
        txtRepetition.setText("Repetition: " +String.valueOf(currentRecord.getRepetition()));
        return oneItem;
    }
}
